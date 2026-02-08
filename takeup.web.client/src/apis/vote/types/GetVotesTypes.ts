export interface GetVotesRequest {
  uniqueId: string
  topicIds: number[]
}

// -----

export interface GetVotesResponse {
  answerId: number
  answerAt: number
  items: GetVotesResponseItem[]
}

export interface GetVotesResponseItem {
  topicId: number
  data: GetVotesResponseItemData[]
}

export interface GetVotesResponseItemData {
  dataId: number
  dataName: string
  numberOfVotes: number
}
