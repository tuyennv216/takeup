export interface GetDataMessageRequest {
  data: GetDataMessageItemRequest[]
}

export interface GetDataMessageItemRequest {
  dataId: number
}

// -----

export interface GetDataMessageResponse {
  anwerId: number
  anwerAt: number
  items: GetDataMessageItemResponse[]
}

export interface GetDataMessageItemResponse {
  dataId: number
  message: string
}
