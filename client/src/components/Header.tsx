"use client"
import { Button } from "@/components/ui/button";
import Link from "next/link"; // Use Next.js Link, not react-router

export default function Header() {
  return (
    <header className="p-4 flex justify-between items-center shadow-sm bg-white">
      <h1 className="text-xl font-extrabold tracking-tight">NEWLIFE <span className="text-sm font-mono tracking-wide">Tracker</span></h1>
      <nav className="space-x-4">
        <Link href="/dashboard"><Button type="button" variant="ghost">Dashboard</Button></Link>
        <Link href="/article"><Button type="button" variant="ghost">Articles</Button></Link>
        <Link href="/challenge"><Button type="button"> Challenge</Button></Link>
      </nav>
    </header>
  );
}
