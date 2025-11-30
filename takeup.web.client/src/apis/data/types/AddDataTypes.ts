export interface AddDataRequest {
  data: AddDataItemRequest[]
}

export interface AddDataItemRequest {
  dataId: number
  message: string
}

// -----

export interface AddDataResponse {
  anwerId: number
  anwerAt: number
}
