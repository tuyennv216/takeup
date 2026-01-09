<template>
  <q-page class="column justify-between">
    <TopicTable />
    <VoteTable />
  </q-page>
</template>

<script setup lang="ts">
  import TopicTable from '@/features/topic/TopicTable.vue'
  import VoteTable from '@/features/vote/VoteTable.vue'
</script>

<style scoped>
</style>
