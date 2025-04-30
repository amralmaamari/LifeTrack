"use client"
import Header from "@/components/Header";
import { useAuth } from "@/context/auth-context";
import { useRouter } from "next/navigation";
import { useEffect } from "react";


export default function ChallengeLayout({ children }: { children: React.ReactNode }) {
     const { isLoggedIn } = useAuth();
        const router = useRouter();
        useEffect(() => {
          if ( !isLoggedIn) {
            router.push("/login");
          }
        }, [ isLoggedIn]);
        if (!isLoggedIn) return null;

  return (
      < >
        <Header />
          <main className="pl-3 pr-4 w-full"> 
          
            {children}
          </main>
      </>
    );
  }
  