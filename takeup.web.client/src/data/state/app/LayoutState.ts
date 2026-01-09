import { defineStore } from 'pinia'

export interface LayoutState {
  menuOpened: boolean
  sidebarOpened: boolean
  showHeader: boolean
  showFooter: boolean
  loading: boolean
}

export const useLayoutState = defineStore('app.layout', {
  state: (): LayoutState => ({
    menuOpened: false,
    sidebarOpened: false,
    showHeader: true,
    showFooter: true,

    loading: false,
  }),
  actions: {
    toggleMenu() {
      this.menuOpened = !this.menuOpened
    },
  },
  persist: {
    key: 'app.layout',
    storage: localStorage,
    pick: [
      'menuOpened',
      'sidebarOpened',
      'showHeader',
      'showFooter',
    ]
  }
})
