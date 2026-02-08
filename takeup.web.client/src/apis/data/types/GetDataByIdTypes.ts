export interface GetDataIdRequest {
  uniqueId: string
  dataIds: string[]
}

// -----

export interface GetDataIdResponse {
  anwerId: number
  anwerAt: number
  items: GetDataIdItemResponse[]
}

export interface GetDataIdItemResponse {
  dataId: number
  message: string
}
