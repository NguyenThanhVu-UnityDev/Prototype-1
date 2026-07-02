# Prototype 1

Một bản prototype mô phỏng lái xe trong lộ trình Junior Programmer Pathway của Unity.

Khác với trong hướng dẫn, prototype này đã được refactor với cấu trúc mã nguồn sạch (tuân thủ các quy ước viết code C# và các nguyên lý Lập trình hướng đối tượng - OOP), di chuyển xe dựa trên vật lý, và nâng cấp hệ thống điều khiển camera.

## Demo Gameplay
![Demo Gameplay](Screenshots/DemoGameplay.gif)

## Những Điều Tôi Đã Học Được

### [Lesson 1.1 - Khởi Động Động Cơ 3D](https://learn.unity.com/pathway/junior-programmer/unit/player-control/tutorial/lesson-1-1-start-your-3d-engines?version=6.0)

**Tính năng mới**

- Khởi tạo dự án và nhập (import) các tài nguyên môi trường ban đầu.
- Định vị phương tiện và các chướng ngại vật trên đường một cách chính xác trong không gian 3D.
- Thiết lập camera ban đầu nằm phía sau phương tiện.

**Khái niệm & kỹ năng mới**

- **Game view vs. Scene view:** Sử dụng cửa sổ Scene để thiết kế bố cục không gian và cửa sổ Game để kiểm tra camera của người chơi.
- **Quy trình làm việc với Hierarchy & Inspector:** Cấu hình các component và thuộc tính không gian trên các GameObject đang hoạt động.
- **Điều hướng không gian 3D:** Thành thạo các thao tác xoay, di chuyển, thu phóng và lấy nét khung nhìn trong không gian ba chiều.

### [Lesson 1.2 - Nhấn Ga Sát Ván (Pedal to the Metal)](https://learn.unity.com/pathway/junior-programmer/unit/player-control/tutorial/1-2-move-the-vehicle-with-your-first-line-of-c?version=6.0)

**Tính năng mới**

- **Di chuyển xe dựa trên vật lý:** Tránh việc dịch chuyển tọa độ trực tiếp bằng `Transform.Translate`. Thay vào đó, triển khai di chuyển bằng lực trong [PlayerController](Assets/Scripts/PlayerController.cs) sử dụng lực vật lý C#.
- **Va chạm môi trường ổn định:** Tích hợp các lực Rigidbody và Collider để ngăn chặn phương tiện bị kẹt/lỗi xuyên qua các vật thể môi trường.

**Khái niệm & kỹ năng mới**

- **Quy chuẩn Code & Tái cấu trúc OOP:** Viết mã nguồn sạch, tách biệt logic, tránh các phụ thuộc cứng (hardcoded) và tuân thủ các nguyên lý lập trình (Đóng gói, Kế thừa, và Đơn nhiệm).
- **Tích hợp Time.deltaTime:** Đưa thời gian cập nhật khung hình vào tính toán vật lý để đảm bảo tốc độ di chuyển đồng bộ trên các máy tính có cấu hình khác nhau.
- **Collider & Rigidbody Physics:** Sử dụng công cụ vật lý của Unity để xác định các tương tác của đối tượng một cách tự nhiên.

### [Lesson 1.3 - Cuộc Đuổi Bắt Tốc Độ Cao](https://learn.unity.com/pathway/junior-programmer/unit/player-control/tutorial/1-3-make-the-camera-follow-the-vehicle-with-variables?version=6.0)

**Tính năng mới**

- **Camera góc nhìn thứ ba xoay quanh xe (Orbiting Camera):** Triển khai thiết lập camera trong [FollowPlayer](Assets/Scripts/FollowPlayer.cs) cho phép xoay mượt mà quanh xe trong không gian thay vì bám theo ở một khoảng cách cố định như bài học gốc.

**Khái niệm & kỹ năng mới**

- **Sử dụng Accessor tùy chỉnh trong C#:** Đảm bảo tính đóng gói dữ liệu của biến (sử dụng các trường private kết hợp thuộc tính serialized hoặc hàm getter public) để bảo vệ tính toàn vẹn của dữ liệu.
- **Bám theo mục tiêu & Nội suy vị trí:** Tính toán động khoảng cách camera để đi theo phương tiện mà không bị giật, lag.

### [Lesson 1.4 - Bước Vào Ghế Lái](https://learn.unity.com/pathway/junior-programmer/unit/player-control/tutorial/lesson-1-4-use-user-input-to-control-the-vehicle?version=6.0)

**Tính năng mới**

- **Tăng tốc động cơ theo Input:** Đọc các nút bấm lên/xuống để tác dụng lực trực tiếp lên phương tiện.
- **Cơ chế bẻ lái chính xác:** Điều chỉnh tính toán vật lý xoay sao cho các thao tác bẻ lái không làm xoay xe trừ khi xe đang thực sự di chuyển (tránh lỗi xe tự xoay tại chỗ khi đứng yên).

**Khái niệm & kỹ năng mới**

- **Vật lý Vector & Lực xoắn (Torque):** Áp dụng lực tương đối theo trục hướng trước của phương tiện.
- **Unity Input Actions:** Thiết lập bản đồ điều khiển động thông qua các trục ngang (horizontal) và dọc (vertical).

## Các Tính Năng Mở Rộng & Cải Tiến (Extras)

- **Tuân thủ lập trình hướng đối tượng (OOP):** Tổ chức lại các script mẫu ban đầu thành các component C# sạch sẽ, tuân thủ 4 trụ cột cốt lõi của OOP (Đóng gói, Trừu tượng, Kế thừa, Đa hình).
- **Hệ thống vật lý dựa trên Rigidbody:** Sử dụng `Rigidbody.AddForce()` để tăng tốc thay vì dịch chuyển tọa độ trực tiếp. Điều này giúp xe không bị lỗi xuyên vật thể và mang lại cảm giác lái chân thực hơn.
- **Cơ chế bẻ lái thực tế:** Các tính toán góc lái phụ thuộc vào vận tốc hiện tại của xe. Xe không thể bẻ lái hoặc tự xoay quanh trục trừ khi đang thực sự di chuyển.
- **Camera góc nhìn thứ ba xoay tự do:** Cho phép người chơi tự do điều khiển xoay camera xung quanh xe bằng chuột/phím, mang lại trải nghiệm lái xe linh hoạt và thú vị hơn so với camera cố định của bài học gốc.
