export interface UpdateDataRequest {
  uniqueId: string
  data: UpdateDataItemRequest[]
}

export interface UpdateDataItemRequest {
  dataId: number
  message: string
}

// -----

export interface UpdateDataResponse {
  anwerId: number
  anwerAt: number
  items: UpdateDataItemResponse[]
}

export interface UpdateDataItemResponse {
  dataId: number
  message: string
}
