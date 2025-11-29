<template>
  <div>
    <q-input v-model="search.text" label="Search Topic" stack-label filled></q-input>
  </div>
</template>

<script setup lang="ts">
  import { ref } from 'vue'

  const search = ref({})
</script>
