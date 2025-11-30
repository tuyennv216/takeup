import type { AxiosResponse } from 'axios';
import { apiInstance } from '@/config/configAxios'

import type { NewVoteRequest, NewVoteResponse } from '@/apis/vote/types/NewVoteTypes'

import type { GetVotesRequest, GetVotesResponse } from '@/apis/vote/types/GetVotesTypes'

// -----

export async function newVote(request: NewVoteRequest) {
  const response: AxiosResponse<NewVoteResponse> = await apiInstance.post("/vote/new-vote", request)

  return response.data
}

// -----

export async function getVotes(request: GetVotesRequest) {
  const response: AxiosResponse<GetVotesResponse> = await apiInstance.post("/vote/get-votes", request)

  return response
}
