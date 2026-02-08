export interface GetDataMessageRequest {
  uniqueId: string
  messages: string[]
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
