"use client";
import { Button } from "@/components/ui/button";
import Link from "next/link";
import { useAuth } from "@/context/auth-context";

export default function Header() {
  const { user, logout } = useAuth();

  return (
    <header className="p-4 flex justify-between items-center shadow-sm bg-white">
      <h1 className="text-xl font-extrabold tracking-tight">
        NEWLIFE <span className="text-sm font-mono tracking-wide">Tracker</span>
      </h1>

      <nav className="flex items-center space-x-2">
        <Link href="/dashboard">
          <Button variant="ghost">Dashboard</Button>
        </Link>
        <Link href="/article">
          <Button variant="ghost">Articles</Button>
        </Link>
           <Link href="/challenge">
          <Button className="bg-gray-500 text-white hover:bg-gray-800">Challenge</Button>
        </Link>

        {user ? (
          <>
            <span className="text-sm font-medium text-gray-700">👋 {user.fullName}</span>
            <Button variant="destructive" onClick={logout}>
              Logout
            </Button>
          </>
        ) : (
          <Link href="/login">
            <Button variant="outline">Login</Button>
          </Link>
        )}
      </nav>
    </header>
  );
}
