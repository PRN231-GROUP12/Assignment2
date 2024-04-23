
import { UpdatePublisher } from '../types/publisher'
import axiosClient from './axios-clients'

export const publisherServices = {
  getPublishers: async () => {
    return await axiosClient.get('/publishers?sortBy=PublisherName&sortOrder=ASC')
  },
  getPublisherDetail: async (id: string) => {
    return await axiosClient.get(`/publishers/${id}`)
  },
  createPublisher: async (data: UpdatePublisher) => {
    return await axiosClient.post('/publishers', data)
  },
  updatePublisher: async (id: string, data: UpdatePublisher) => {
    return await axiosClient.put(`/publishers/${id}`, data)
  },
  deletePublisher: async (id: string) => {
    return await axiosClient.delete(`/publishers/${id}`)
  },
}
