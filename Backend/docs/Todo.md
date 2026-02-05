List chức năng (todos):

Thứ tự triển khai: Auth → Product → Inventory → Cart → Order → Payment → Admin/Statistic

1. Auth (Auth, User, Address): 
- Đăng ký, đăng nhập, đăng xuất, refresh token...
- Lấy thông tin người dùng hiện tại 
- Cập nhật hồ sơ
- Đổi mật khẩu
- Quản lý danh sách địa chỉ, đặt địa chỉ mặc định và dữ liệu địa chỉ động.

2. Product (Category, Product): 
- CRUD cat có cấu trúc cha con 
- CRUD product
- Bật tắt trạng thái hiển thị
- Lấy danh sách có phân trang
- Xem chi tiết, tìm kiếm và lọc theo danh mục, giá và trạng thái.

3. Inventory (Warehouse, Inventory):
- Tạo kho
- Nhập hàng
- Xuất hàng 
- Điều chỉnh tồn
- Xem tồn hiện tại theo sản phẩm hoặc theo kho
- Theo dõi lịch sử giao dịch 
- Kiểm tra đủ tồn trước khi cho phép đặt hàng

4. Cart: 
- Tạo
- Lấy cart active
- Thêm sản phẩm
- Cập nhật số lượng
- Xóa sản phẩm
- Làm trống giỏ
- Kiểm tra tồn kho trước khi chuyển sang đặt hàng.

5. Order: 
- Tạo order từ cart
- Lưu snapshot địa chỉ và giá tại thời điểm đặt
- Cho phép hủy trước khi giao
- Cập nhật trạng thái đơn theo quy trình xử lý
- Xem danh sách và chi tiết đơn.

6. Payment: 
- Tạo thanh toán
- Cập nhật trạng thái thành công hoặc thất bại
- Hỗ trợ thanh toán lại 
- Theo dõi lịch sử thanh toán theo đơn hoặc theo người dùng.

7. Statistic.
- Dashboard doanh thu
- Tổng số đơn
- Sản phẩm bán chạy
- Bonus: Kiểm soát quyền truy cập quản trị, lưu log hoạt động quan trọng, soft delete