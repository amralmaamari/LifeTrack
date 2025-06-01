"use client"
import { useParams } from "next/navigation";

import CreateArticleForm from '@/components/CreateArticleForm'


export default function Page() {
   const { id } = useParams();
  

  return (
    
    <div className='mt-3'>
        <CreateArticleForm articleId={id } />
       
    
        </div>
  )
}
