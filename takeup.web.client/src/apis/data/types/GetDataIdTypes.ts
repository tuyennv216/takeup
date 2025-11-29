export interface GetDataIdRequest {
  data: GetDataIdItemRequest[]
}

export interface GetDataIdItemRequest {
  message: string
}

// ----- //

export interface GetDataIdResponse {
  anwerId: number
  anwerAt: number
  items: GetDataIdItemResponse[]
}

export interface GetDataIdItemResponse {
  dataId: number
  message: string
}

// ----- //
