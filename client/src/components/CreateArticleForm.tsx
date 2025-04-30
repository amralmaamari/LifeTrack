"use client";

import { useRouter, useSearchParams } from "next/navigation";
import { useEffect, useState } from "react";
import { Input } from "@/components/ui/input";
import { Button } from "@/components/ui/button";
import Tiptap from "./Tiptap";
import useFetch from "@/hooks/useFetch";
import axios from "axios";
import toast from "react-hot-toast";

export default function CreateArticleForm() {
  const router = useRouter();
  const searchParams = useSearchParams();
  
  const [title, setTitle] = useState("");
  const [content, setContent] = useState("");
  
  // جلب بيانات المقال لو بنعدل
  
  const articleId  = searchParams.get("id");
  
  const { data, error, loading } = useFetch({ url: `/Article/${articleId}` });
  
  useEffect(()=>{
    if(data){
      setTitle(data.title);
      setContent(data.description);
    }
  },[data])
  const apiUrl = process.env.NEXT_PUBLIC_API_URL;

  const handleSubmit = async () => {
    try {
      let response;
  
      if (articleId) {        
        // ✅ PUT (تحديث مقال)
        response = await axios.put(`${apiUrl}/Article/${articleId}`, {
          articleID: articleId,
          title: title,
          description:  content
        }, {
          headers: {
            "Content-Type": "application/json"
          }
        });
        toast.success("✅ تم تحديث المقالة!");

  
      } else {
        // ✅ POST (إنشاء مقال جديد)
        response = await axios.post(`${apiUrl}/Article`, {
          title: title,
          description: content,
          userID: 1
        }, {
          headers: {
            "Content-Type": "application/json"
          }
        });
        
        toast.success("✅ تم إنشاء المقالة!");
        router.push(`/article/edit?id=${response.data.data.articleID}`);
      }
  

    } catch (error) {
      if (axios.isAxiosError(error)) {
        toast.error("❌ Axios Error:", error.response?.data || error.message);
      } else {
        toast.error("❌ Unknown Error:", error);
      }
    }
  };

  return (
    <>
   
    <form className="space-y-4 bg-white p-6 rounded-xl shadow ">
      <h1 className="text-xl font-bold" dir="rtl">
        {articleId ? "تعديل المقالة" : "إنشاء مقالة جديدة"}
      </h1>

      <Input
        dir="rtl"
        placeholder="عنوان المقالة"
        className="my-3"
        value={title}
        onChange={(e) => setTitle(e.target.value)}
      />
      

      

      <Tiptap  value={content} onChange={setContent} />

      <Button type="button" onClick={handleSubmit}>
        {articleId ? "تحديث" : "إنشاء"}
      </Button>
    </form>

  </>
  );
}
