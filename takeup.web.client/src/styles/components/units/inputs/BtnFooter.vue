<template>
  <BtnBase height="28px"
           v-bind="$attrs">
    <slot />
  </BtnBase>
</template>

<script lang="ts">
  import { defineComponent } from 'vue'
  import BtnBase from './BtnBase.vue'

  export default defineComponent({
    name: 'BtnFooter',
    components: {
      BtnBase
    },
    // Kế thừa attrs để truyền xuống BtnBase
    inheritAttrs: false,
  })
</script>

<style scoped>
</style>
