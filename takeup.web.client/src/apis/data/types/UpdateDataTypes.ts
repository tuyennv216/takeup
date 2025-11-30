export interface UpdateDataRequest {
  data: UpdateDataItemRequest[]
}

export interface UpdateDataItemRequest {
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
