import { Layout, LayoutBody, LayoutHeader } from '@/components/custom/layout'
import ThemeSwitch from '@/components/theme-switch'
import { UserNav } from '@/components/user-nav'
import { columns } from './components/columns'
import { DataTable } from './components/data-table'
// import { publishers } from './data/publishers'
import { publisherServices } from '@/services/publisher.service'
import { useEffect, useState } from 'react'


export default function Publishers() {

  const [data, setData] = useState([])

  useEffect(() => {
    const getDataPublisher = async () => {
      const res = await publisherServices.getPublishers()
      setData(res.data.items)
    }
    getDataPublisher()
  }, [])

  return (
    <Layout>
      {/* ===== Top Heading ===== */}
      <LayoutHeader>
        {/* <Search /> */}
        <div className='ml-auto flex items-center space-x-4'>
          <ThemeSwitch />
          <UserNav />
        </div>
      </LayoutHeader>

      <LayoutBody className='flex flex-col' fixedHeight>
        <div className='mb-2 flex items-center justify-between space-y-2'>
          <div>
            <h2 className='text-2xl font-bold tracking-tight'>Welcome back!</h2>
            <p className='text-muted-foreground'>
              Here&apos;s a list of your publishers information!
            </p>
          </div>
        </div>
        <div className='-mx-4 flex-1 overflow-auto px-4 py-1 lg:flex-row lg:space-x-12 lg:space-y-0'>
          <DataTable data={data} columns={columns} />
        </div>
      </LayoutBody>
    </Layout>
  )
}
