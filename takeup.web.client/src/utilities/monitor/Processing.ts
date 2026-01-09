import { defineStore } from 'pinia'

export interface Processing {
  items: Record<string, ProcessItem>
}

export const useProcessing = defineStore('process.cache', {
  state: (): Processing => ({
    items: {}
  }),

  persist: {
    key: 'process.cache',
    storage: localStorage,
    pick: [
      'items'
    ]
  }
})

export interface ProcessItem {
  type: ProcessType;
  step: ProcessStep;
  data: object;
}

export enum ProcessType {
  Data = 1,
  Vote = 2,
  Topic = 3,
}

export enum ProcessStep {
  New = 0,
  Inprogress = 1,
  Wait = 2,
  Success = 3,
  Failed = 4,
  Error = 5,
}
