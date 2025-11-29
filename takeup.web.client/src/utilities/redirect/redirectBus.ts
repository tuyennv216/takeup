import mitt from 'mitt'

// Định nghĩa danh sách event types với payload tương ứng
type Events = {
  'to': { path: string; param?: { [key: string]: string } }
}

// Tạo event bus với type safety
const redirectBus = mitt<Events>()

export default redirectBus
