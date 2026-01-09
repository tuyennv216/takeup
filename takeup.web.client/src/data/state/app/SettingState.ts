import { defineStore } from 'pinia'

export interface SettingState {
  tabTitle: string
  appTitle: string
  status: string
  theme: 'light' | 'dark'
}

export const useSettingState = defineStore('app.setting', {
  state: (): SettingState => ({
    tabTitle: '',
    appTitle: '',
    status: '',
    theme: 'light'
  }),

  persist: {
    key: 'app.setting',
    storage: localStorage,
    pick: [
      'tabTitle',
      'appTitle',
      'status',
      'theme'
    ]
  }
})
