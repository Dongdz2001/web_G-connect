import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'
import tsconfigPaths from 'vite-tsconfig-paths'
// https://vitejs.dev/config/
export default defineConfig({
  server: {
    port: 8087,
    host: '0.0.0.0'
  },
  plugins: [react(),tsconfigPaths()]
})
