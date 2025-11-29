import axios from 'axios'

import configHost from './configHost'

export const apiInstance = axios.create({
  baseURL: configHost.topic.api,
  headers: {
    'Content-Type': 'application/json',
  },
})
