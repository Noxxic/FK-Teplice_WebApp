var path = require('path');
var webpack = require('webpack');
const ExtractTextPlugin = require('extract-text-webpack-plugin');

module.exports = function (env) {

    env = env || {};

    var config = {
        
        entry: {
           main: path.join(__dirname, 'wwwroot/src/main.js'),
        },
        output: {
            path: path.join(__dirname, 'wwwroot/dist'),
            filename: '[name].js'
        },
        devtool: 'eval-source-map',
        resolve: {
            extensions: ['.ts', '.tsx', '.js', '.jsx']
        },
        plugins: [
            new webpack.ProvidePlugin({ $: 'jquery', jQuery: 'jquery' }),
            new ExtractTextPlugin('style.css')
        ],
        module: {
            rules: [
                { test: /\.css?$/, use: ExtractTextPlugin.extract({
                    fallback: "style-loader",
                    use: "css-loader"
                  }) },
                { test: /\.(png|jpg|jpeg|gif|svg)$/, use: 'url-loader?limit=25000' },
                { test: /\.(png|woff|woff2|eot|ttf|svg)(\?|$)/, use: 'url-loader?limit=100000' }
            ]
        }
    }

    if (env.NODE_ENV === 'production') {
        config.devtool = 'source-map';
        config.plugins = config.plugins.concat([
            new webpack.optimize.UglifyJsPlugin({
                sourceMap: true
            })
        ]);
    }

    return config;
};