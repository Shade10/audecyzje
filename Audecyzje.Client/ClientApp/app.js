import Vue from 'vue'
import axios from 'axios'
import router from './router'
import store from './store'
import { sync } from 'vuex-router-sync'
import App from 'components/app-root'
import VueFuse from 'vue-fuse'

Vue.use(VueFuse)

Vue.prototype.$http = axios;

sync(store, router)

const app = new Vue({
    store,
    router,
    ...App
}).$mount('#app')

export {
    app,
    router,
    store
}
