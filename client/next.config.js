/** @type {import('next').NextConfig} */
const nextConfig = {
    // switch back to SSR
    // output: 'export',    ← make sure this line is removed or commented
    images: { unoptimized: true },
    eslint: { ignoreDuringBuilds: true },
    typescript: { ignoreBuildErrors: true },
  };
  module.exports = nextConfig;