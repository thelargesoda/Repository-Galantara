GALANTARA 

Dibuat oleh 
Andhika Pandya Wijaya       	- Game Programer
Miftahul Zanah 	             - Project Manager
Lula Neya Kamila 		(2409085)	- Game Designer



In Game asset
Assets/
 ├─ Animation               -> Berisi animasi karakter dan objek.
 ├─ AnimationUI            -> Animasi khusus UI (button, transition, dll).
 ├─ Character              -> Model dan asset karakter.
 ├─ Fonts                  -> Kumpulan font untuk kebutuhan UI.
 ├─ Material               -> Material objek 2D/3D (shader, warna, textures).
 ├─ Object                 -> Kumpulan object gameplay (obstacle, item, dll).
 ├─ Scenes                 -> Scene game (Main Menu, Level, Sample Scene, dll).
 ├─ Script                 -> Semua script utama gameplay.
 ├─ TerrainBehavior        -> Asset/script khusus terrain & lingkungan.
 ├─ UI                     -> Prefab UI seperti panel, menu, button, dll.
 └─ Unity Pack             -> Asset pack dari Unity Store.



Base class script information:

PlayerMovement
Mengatur gerakan dasar player: maju otomatis, kiri/kanan, lompat, dan stop saat game over.

Collision.cs
Base class untuk semua rintangan; mendeteksi tabrakan dan memicu EndGame() secara otomatis.

EndTrigger.cs
Dipasang di garis akhir level; mendeteksi player dan menjalankan NextLevel() atau EndGame(), sesuai kondisi player.

FollowPlayer.cs
Mengatur kamera agar mengikuti player dengan offset stabil.

GameSystem.cs
Manajemen state utama: mulai, selesai, game over, restart, dan UI level.

Score.cs
Menghitung skor (berdasarkan jarak) dan mengupdate UI secara real-time.

Next Level
Class yang khusus untuk memindahkan level ke satu level lainya

Player Animation
Class yang menyimpan berbagai data eksekusi animasi untuk model player
