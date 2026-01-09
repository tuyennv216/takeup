<template>
  <div>
    <q-input @keydown.enter="onSearchEnter" v-model="topicManagementState.search" placeholder="Nhập chủ đề" stack-label
      filled></q-input>
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue'

import { useTopicManagementState } from '@/data/state/page/TopicManagementState'
import { useProcessing } from '@/utilities/monitor/Processing';

import { addTopic } from '@/apis/topic/TopicApis'
import { uuid, uuidStr } from '@/utilities/common/securities';
import { ProcessType, ProcessStep } from '@/utilities/monitor/Processing'

const topicManagementState = useTopicManagementState()
const processing = useProcessing()

function onSearchEnter() {
  const topicText = topicManagementState.search.trim();
  const topicHash = uuidStr(topicText)

  // Kiểm tra nếu cần gọi api
  let callApi = false
  if (!processing.items[topicHash]) {
    processing.items[topicHash] = {
      type: ProcessType.Topic,
      step: ProcessStep.Inprogress,
      data: {
        text: topicText
      }
    }

    callApi = true
  }
  else if (processing.items[topicHash].step === ProcessStep.Failed || processing.items[topicHash].step === ProcessStep.Error) {
    processing.items[topicHash].step = ProcessStep.Inprogress
    callApi = true
  }
  // End Kiểm tra nếu cần gọi api

  if (callApi === true) {
    const addNew = addTopic({
      uniqueId: uuid(),
      topics: [topicText]
    })

    addNew.then(res => {
      if (res.status === 200) {
        processing.items[topicHash].step = ProcessStep.Success

        const newItems = res.data.items.map(x => ({
          topicId: x.topicId,
          topicName: x.topicName,
          online: 1,
          answerAt: res.data.answerAt
        }))
        
        topicManagementState.items.push(...newItems)
      }
    })
  }
}

</script>
