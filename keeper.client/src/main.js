import 'bootstrap'
import 'jquery'
import 'popper.js'
import '@mdi/js'
import '@mdi/font/css/materialdesignicons.css'

import { createApp } from 'vue'
// @ts-ignore
import App from './App.vue'
import { registerGlobalComponents } from './registerGlobalComponents'
import { router } from './router'

const root = createApp(App)
registerGlobalComponents(root)

root
  .use(router)
  .mount('#app')
