<template>
  <q-dialog persistent 
    transition-show="none"
    transition-hide="none">
    <q-card class="card-container">
      <div class="row" style="flex-grow: 1;">
        <!-- Tabs bên trái -->
        <div class="col-2">
          <q-tabs v-model="tab"
                  vertical
                  class="text-primary"
                  active-color="primary"
                  indicator-color="primary">

            <q-tab name="intro" icon="info" label="Giới thiệu" no-caps />
            <q-tab name="guide" icon="menu_book" label="Hướng dẫn" no-caps />
          </q-tabs>
        </div>

        <!-- Nội dung bên phải -->
        <div class="col-10">
          <q-tab-panels v-model="tab">
            <q-tab-panel name="intro">
              <Intro />
            </q-tab-panel>

            <q-tab-panel name="guide">
              <Guide />
            </q-tab-panel>
          </q-tab-panels>
        </div>
      </div>

      <q-card-actions class="column justify-between">
        <div class="full-width flex justify-end">
          <q-btn style="min-width: 150px;" no-caps color="primary" unelevated v-close-popup>Đóng</q-btn>
        </div>

        <q-separator class="full-width q-my-sm" />

        <div class="full-width row q-pl-sm">
          <div style="flex-grow: 1;">
            <div>Chịu trách nhiệm nội dung: Nguyễn Văn Tuyến</div>
            <div>Địa chỉ: Anh Khánh, Hà Nội</div>
            <div>Số điện thoại: 0336654132</div>
            <!--<div>Email: <a href="mailto:lienhe@sanvieclam.pro.vn">lienhe@sanvieclam.pro.vn</a></div>-->
          </div>

          <div class="row items-end">
            <!--<span @click="openPolicyActivity" class="button-link">Chính sách hoạt động</span>-->
          </div>
        </div>
      </q-card-actions>
    </q-card>
  </q-dialog>
</template>

<script setup lang="ts">
  import { ref } from 'vue'
  import { Dialog } from 'quasar'

  import Intro from './Intro.vue'
  import Guide from './Guide.vue'

  const tab = ref("intro")

  function openPolicyActivity() {
    //Dialog.create({
    //  component: PolicyActivity,
    //})
  }
</script>

<style scoped>
  .card-container {
    display: flex;
    flex-direction: column;
    min-width: 700px;
    min-height: 500px;
  }

  .card-main-section {
    flex-grow: 1;
    flex-direction: column;
  }

  .info-description {
    flex-grow: 1;
  }

  .button-link {
    cursor: pointer;
    color: #00BD7E;
  }

    .button-link:hover {
      text-decoration: underline;
    }
</style>
