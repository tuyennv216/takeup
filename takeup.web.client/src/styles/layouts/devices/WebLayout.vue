<template>
  <q-layout view="hHh lpR fFf">

    <slot name="header">
      <DefaultHeader />
    </slot>

    <slot name="menu">
      <DefaultMenu />
    </slot>

    <q-page-container>
      <slot name="content">
        <router-view />
      </slot>
    </q-page-container>

    <slot name="footer">
      <DefaultFooter />
    </slot>

  </q-layout>
</template>

<script setup lang="ts">
  import DefaultMenu from '@/styles/components/groups/navigations/DefaultMenu.vue'
  import DefaultHeader from '@/styles/components/groups/navigations/DefaultHeader.vue'
  import DefaultFooter from '@/styles/components/groups/navigations/DefaultFooter.vue'
</script>
