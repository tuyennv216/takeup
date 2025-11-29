// src/routers/AppRouter.ts
import { createRouter, createWebHistory } from 'vue-router'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      children: [
        {
          path: '/',
          name: 'Topic Management',
          component: () => import('@/pages/topic/TopicManagement.vue'),
        },
      ],
    },
  ]
})

export default router
