// src/router/index.ts
import { createRouter, createWebHistory } from 'vue-router'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      children: [
        {
          path: '/',
          name: 'Homepage',
          component: () => import('@/pages/HomePage.vue'),
        },
        {
          path: '/about',
          name: 'about',
          component: () => import('@/pages/AboutPage.vue')
        }
      ],
    },
  ]
})

export default router
