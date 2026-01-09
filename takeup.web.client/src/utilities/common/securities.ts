import { v4 as uuidv4, v5 as uuidv5 } from 'uuid';

// Namespace ngẫu nhiên để đảm bảo tính duy nhất cho dự án
const MY_NAMESPACE = '4c088530-baa8-4c1c-b4ef-91af44eacb29';

// Tạo ID ngẫu nhiên (v4)
export const uuid = () => {
  return uuidv4();
}

/**
 * Tạo ID từ một chuỗi string (v5)
 * Cùng một đầu vào sẽ luôn trả về cùng một ID
 */
export const uuidStr = (name: string) => {
  return uuidv5(name, MY_NAMESPACE);
}
