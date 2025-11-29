import redirectBus from '@/utilities/redirect/redirectBus'

export const redirect = (path: string, param?: { [key: string]: string }) => {
  redirectBus.emit("to", { path, param })
}

export const redirectParams = (path: string, ...arr: string[]) => {
  const param: { [key: string]: string } = {}

  // Đảm bảo số lượng phần tử chẵn
  if (arr.length % 2 !== 0) {
    console.warn('redirectParam: Số lượng tham số phải là chẵn')
    return
  }

  for (let i = 0; i < arr.length; i += 2) {
    param[arr[i]] = arr[i + 1]
  }

  redirectBus.emit("to", { path, param })
}
