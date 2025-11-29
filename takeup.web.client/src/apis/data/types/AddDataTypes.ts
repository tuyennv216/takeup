export interface UpdateDataRequest {
  data: UpdateDataItemRequest[]
}

export interface UpdateDataItemRequest {
  dataId: number
  message: string
}

// ----- //

export interface UpdateDataResponse {
  anwerId: number
  anwerAt: number
}

// ----- //
