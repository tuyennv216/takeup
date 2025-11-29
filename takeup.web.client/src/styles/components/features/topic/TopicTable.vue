<template>
  <div>
    <TopicSearch />
    <q-table :rows="[]" flat bordered>

      <template v-slot:no-data="{ icon, message, filter }"></template>
    </q-table>
  </div>
</template>

<script setup lang="ts">
  import TopicSearch from '@/styles/components/features/topic/TopicSearch.vue'
</script>
