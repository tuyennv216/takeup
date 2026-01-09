<template>
  <div class="row items-center">
    <!-- <q-input v-model="topicManagementState.keyword" placeholder="Nhập từ khóa..." filled dense class="col" /> -->
    <q-select v-model="topicManagementState.keyword" use-input fill-input hide-selected input-debounce="1000"
      :options="options" @filter="filterVoteFun" filled dense class="col" placeholder="Nhập để tìm kiếm..."
      option-label="message" option-value="dataId">
      <template v-slot:no-option>
        <q-item>
          <q-item-section class="text-grey">
            Không tìm thấy kết quả
          </q-item-section>
        </q-item>
      </template>
    </q-select>

    <q-btn color="primary" label="Vote" @click="onVoteClick" unelevated class="q-mx-sm" />
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue'

import { useTopicManagementState } from '@/data/state/page/TopicManagementState'

const topicManagementState = useTopicManagementState()

const mockOptions = [
  {
    dataId: 1,
    message: "a1"
  },
  {
    dataId: 2,
    message: "b2"
  },
  {
    dataId: 3,
    message: "c3"
  }
];

const options = ref(mockOptions)
const filterVoteFun = async (val: string, update: any) => {
  if (val === '') {
    topicManagementState.keyword = ""
    update(() => {
      options.value = mockOptions
    })
    return
  }

  try {
    const needle = val.toLowerCase()

    update(() => {
      options.value = mockOptions.filter(
        v => v.message.toLowerCase().indexOf(needle) > -1
      )
    })

    // const response = await api.get('/topics/search', { params: { q: val } })

    // update(() => {
    //   // Gán kết quả trả về vào options để hiển thị trong dropdown
    //   options.value = response.data.items
    // })
  } catch (error) {
    console.error("Search error:", error)
    update(() => { options.value = [] })
  }
}

function onVoteClick() {

}
</script>