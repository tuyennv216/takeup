export interface AddDataRequest {
  uniqueId: string
  messages: string[]
}

// -----

export interface AddDataResponse {
  anwerId: number
  anwerAt: number
}
