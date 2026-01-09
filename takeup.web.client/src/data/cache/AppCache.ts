import { defineStore } from 'pinia'

import { DataModel } from '@/data/model/data/DataModel'

import { getDataMessage } from '@/apis/data/DataApis'

export interface AppCache {
  data: DataModel[]
}

export const useAppCache = defineStore('app.cache', {
  state: (): AppCache => ({
    data: [
      {
        dataId: 1,
        message: "a1"
      },
      {
        dataId: 2,
        message: "a2"
      },
      {
        dataId: 3,
        message: "a3"
      }
    ]
  }),

  actions: {
    async getData(ids: number[]): Promise<DataModel[]> {
      const kItems: DataModel[] = []
      const mIds: number[] = []

      // 1. Phân loại id: cái nào có sẵn, cái nào thiếu
      for (const id of ids) {
        const item = this.data.find(d => d.dataId === id)
        if (item) {
          kItems.push(item)
        } else {
          mIds.push(id)
        }
      }

      // 2. Nếu không thiếu id nào, trả về ngay lập tức
      if (mIds.length === 0) {
        return kItems
      }

      // 3. Nếu thiếu, gọi API và chờ kết quả
      try {
        const res = await getDataMessage({
          data: mIds.map(m => ({ dataId: m }))
        })

        if (res.status === 200 && res.data) {
          const newItems: DataModel[] = res.data.items
          this.data.push(...newItems)
          return [...kItems, ...newItems]
        }
      } catch (error) {
        console.error("Lỗi khi lấy thêm dữ liệu:", error)
      }

      return kItems
    }
  },

  persist: {
    key: 'app.cache',
    storage: localStorage,
    pick: [
      'data'
    ]
  }
})
