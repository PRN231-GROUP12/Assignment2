import axiosClient from './axios-clients'
import { UpdateAuthor } from '@/types/author'

export const authorServices = {
  getAuthors: async () => {
    return await axiosClient.get('/authors')
  },
  getAuthorDetail: async (id: string) => {
    return await axiosClient.get(`/authors/${id}`)
  },
  createAuthor: async (data: UpdateAuthor) => {
    return await axiosClient.post('/authors', data)
  },
  updateAuthor: async (id: string, data: UpdateAuthor) => {
    return await axiosClient.put(`/authors/${id}`, data)
  },
  deleteAuthor: async (id: string) => {
    return await axiosClient.delete(`/authors/${id}`)
  },
}