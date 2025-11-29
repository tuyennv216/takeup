import 'material-symbols/index.css'
import '@mdi/font/css/materialdesignicons.css'

import '@/styles/assets/main.css'

import { createApp } from 'vue'
import { createPinia } from 'pinia'
import piniaPluginPersistedstate from 'pinia-plugin-persistedstate'
import App from '@/App.vue'
import router from '@/routers/AppRouter'

// Quasar imports
import { Quasar, Dialog, Notify } from 'quasar'
import '@quasar/extras/material-icons/material-icons.css'
import 'quasar/src/css/index.sass'

const pinia = createPinia()
pinia.use(piniaPluginPersistedstate)

const app = createApp(App)

app.use(pinia)

app.use(Quasar, {
  plugins: {
    Dialog,
    Notify
  },
})

app.use(router)

app.mount('#app')
