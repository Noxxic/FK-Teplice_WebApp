using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;


using Microsoft.EntityFrameworkCore;
using FKTeplice.Models;
using System.Collections;
using System.Threading.Tasks;
using FKTeplice.Data;
using Microsoft.AspNetCore.Http;
using System.Globalization;

namespace FKTeplice.BusinessModels.PhysioParser
{
    public static class PhysioParser
    {
        private static int Offset { get; } = 2;
        private static int HeaderRow { get; } = 1;

        private static DateTime[] GetDates(ISheet sheet, int row, int offset) {
            var r = sheet.GetRow(row);
            var res = new DateTime[r.LastCellNum + 1]; 
            var cinfo = new CultureInfo("cs-CZ");

            if(r != null) {
                for(int i = offset; i <= r.LastCellNum; i++) {
                    DateTime date = new DateTime();
                    DateTime.TryParse(r.GetCell(i)?.ToString() ?? "", out date);
                    res[i] = date;
                }
            }

            return res;
        } 

        private static Physio GetPhysio(int playerId, int competitionId, DateTime date, ApplicationDbContext _context) {
            var e = _context.Physios
                            .Where(x => x.PlayerId == playerId && x.CompetitionId == competitionId && date == x.Date)
                            .FirstOrDefault();

            return (e != null ? _context.Physios.Update(e) : _context.Physios.Add(                
                new Physio() {
                    PlayerId = playerId,
                    CompetitionId = competitionId,
                    Date = date,   
                }
            )).Entity;
        }

        private static Competition GetCompetition(string name, ApplicationDbContext _context) {
            var e = _context.Competitions.Where(x => x.Name == name).FirstOrDefault();
            return (e != null ? _context.Competitions.Update(e) : _context.Competitions.Add(
                new Competition() {
                    Name = name,
                    Alias = name,
                    LabelX = "x",
                    LabelY = "y"
                }
            )).Entity;
        }

        private static Player GetPlayer(string name, string year, ApplicationDbContext _context) {
            return _context.Players
                            .Where(x => $"{x.FirstName} {x.LastName}" == name && x.Birthday.Year.ToString() == year)
                            .FirstOrDefault();
        }

        public static async void FromExcel(IFormFile file, ApplicationDbContext _context) {
            //await Task.Run(() => {
                using(Stream stream = file.OpenReadStream())
                {
                    IWorkbook wb = WorkbookFactory.Create(stream);
                    Competition[] comps = new Competition[wb.NumberOfSheets];

                    for(int i = 0; i < wb.NumberOfSheets; i++) {
                        ISheet sheet = wb.GetSheetAt(i);
                        comps[i] = GetCompetition(sheet.SheetName, _context);
                    }

                  //  _context.Competitions.AddRange(comps);
                    _context.SaveChanges();

                    for(int i = 0; i < wb.NumberOfSheets; i++) {
                        ISheet sheet = wb.GetSheetAt(i);
                        DateTime[] dates = GetDates(sheet, HeaderRow, Offset);
                        List<Physio> physios = new List<Physio>();

                        for(int j = HeaderRow + 1; j <= sheet.LastRowNum; j++) {
                            IRow row = sheet.GetRow(j);

                            if(row == null)
                                continue;

                            Player player = GetPlayer(row.GetCell(0)?.ToString(), row.GetCell(1)?.ToString(), _context);

                            if(player != null) {
                                for(int k = Offset; k <= row.LastCellNum; k++) {
                                    ICell cell = row.GetCell(k);
                                    
                                    if(!String.IsNullOrWhiteSpace(cell?.ToString())) {
                                        Physio temp = GetPhysio(player.Id, comps[i].Id, dates[k], _context);
                                        temp.Result = cell.ToString();
                                        physios.Add(temp);
                                    }
                                }
                            }
                        }

                        
                        //_context.Physios.AddRange(physios);
                    }

                    _context.SaveChanges();
                }
            //});
        }

    }
}