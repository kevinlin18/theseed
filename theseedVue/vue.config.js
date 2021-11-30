module.exports = {
  "publicPath": "./",
  "productionSourceMap": false,
  "devServer": {
    "port": 8080,
    "proxy": {
      "/": {
        "target": "http://localhost:22982/",
        "ws": false,
        "changeOrigin": true
      }
    }
  },
  "transpileDependencies": [
    "vuetify"
  ]
}