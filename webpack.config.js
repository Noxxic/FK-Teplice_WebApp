var path = require('path');
var webpack = require('webpack');

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
            new webpack.ProvidePlugin({ $: 'jquery', jQuery: 'jquery' })
        ],
        module: {
            rules: [
                { test: /\.css?$/, use: ['style-loader', 'css-loader'] }
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