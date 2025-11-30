<template>
  <div>
    <q-input v-model="topicManagementState.search" label="Topic" stack-label filled></q-input>
  </div>
</template>

<script setup lang="ts">
  import { ref } from 'vue'

  import { useTopicManagementState } from '@/data/pagestate/TopicManagementState'

  const topicManagementState = useTopicManagementState()
</script>
