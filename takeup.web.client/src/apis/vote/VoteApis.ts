import { apiInstance } from '@/config/configAxios'

import type { NewVoteRequest, NewVoteResponse } from '@/apis/vote/types/NewVoteTypes'

import type { GetVotesRequest, GetVotesResponse } from '@/apis/vote/types/GetVotesTypes'

// ----- //

export const newVote: NewVoteResponse = function (request: NewVoteRequest) {
  const response = apiInstance.post("/vote/new-vote", request)

  return response
}

// ----- //

export const getVotes: GetVotesResponse = function (request: GetVotesRequest) {
  const response = apiInstance.post("/vote/get-votes", request)

  return response
}

// ----- //
