const path = require('path');
const MiniCssExtractPlugin = require("mini-css-extract-plugin");
const { CleanWebpackPlugin } = require('clean-webpack-plugin');
const bundleFileName = 'bundle';
const dirName = 'wwwroot/dist';
module.exports = (env, argv) => {
    return {
        mode: argv.mode === "production" ? "production" : "development",
        entry: ['./src/index.js', './src/sass/index.scss'],
        output: {
            filename: bundleFileName + '.js',
            path: path.resolve(__dirname, dirName)
        },
        module: {
            rules: [
                {
                    test: /\.s[c|a]ss$/,
                    use:
                        [
                            'style-loader',
                            MiniCssExtractPlugin.loader,
                            'css-loader',
                            {
                                loader: 'postcss-loader',
                                options: {
                                    // All postcss options is now under `postcssOptions`
                                    postcssOptions: {
                                        config: path.resolve('src/sass', 'postcss.config.js'),
                                    },
                                    sourceMap: true,
                                },
                            },
                            'sass-loader'
                        ]
                }
            ]
        },
        plugins: [
            new CleanWebpackPlugin(),
            new MiniCssExtractPlugin({
                filename: bundleFileName + '.css'
            })
        ]
    };
};