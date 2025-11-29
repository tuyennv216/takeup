export interface GetVotesRequest {
  topics: GetVotesRequestItem[]
}

export interface GetVotesRequestItem {
  topicId: number
}

// ----- //

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
  numberOfVotes: number
}

// ----- //
