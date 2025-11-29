import { defineStore } from 'pinia'

export interface SettingState {
  tabTitle: string
  appTitle: string
  status: string
  theme: 'light' | 'dark'
}

export const useSettingState = defineStore('setting', {
  state: () => ({
    tabTitle: '',
    appTitle: '',
    status: '',
    theme: 'light'
  }),

  persist: {
    key: 'setting-state',
    storage: localStorage,
    pick: [
      'tabTitle',
      'appTitle',
      'status',
      'theme'
    ]
  }
})
