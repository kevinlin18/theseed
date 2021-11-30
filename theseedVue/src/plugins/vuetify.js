import Vue from 'vue';
import Vuetify from 'vuetify/lib';
import '@mdi/font/css/materialdesignicons.css'
import zhHant from 'vuetify/es5/locale/zh-Hant'

Vue.use(Vuetify);

export default new Vuetify({
    lang: {
      locales: { zhHant },
      current: 'zhHant'
    },
    icons: {
      iconfont: 'mdi',
    },
});
