export interface AddDataRequest {
  data: AddDataItemRequest[]
}

export interface AddDataItemRequest {
  message: string
}

// ----- //

export interface AddDataResponse {
  anwerId: number
  anwerAt: number
  items: AddDataItemResponse[]
}

export interface AddDataItemResponse {
  dataId: number
  message: string
}

// ----- //
