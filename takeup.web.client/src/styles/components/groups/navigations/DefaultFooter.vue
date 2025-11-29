<template>
  <AppFooter>
    <template v-slot:left>
      <BtnFooter min width="28px"><q-icon name="mdi-cog" /></BtnFooter>
    </template>

    <template v-slot:middle>
    </template>

    <template v-slot:right>
      <BtnFooter min width="28px" color="white" @click="openAbout">
        <q-icon name="mdi-information" color="primary" />
      </BtnFooter>
    </template>
  </AppFooter>
</template>

<script setup lang="ts">
  import AppFooter from '@/styles/components/units/navigations/AppFooter.vue'
  import BtnFooter from '@/styles/components/units/inputs/BtnFooter.vue'

  import { Dialog } from 'quasar'
  import About from '@/styles/components/groups/about/About.vue'

  const openAbout = () => {
    Dialog.create({
      component: About,
    })
  }
</script>
