# 餐饮项目

**经理：**

账号：root

密码：123

**店员：**

账号：test

密码：123

# 管理员表ManagerInfo

| 列名 | 类型 | 约束 | 说明 |
| --- | --- | --- | --- |
| MId | integer | 主键，自增长 | 编号 |
| MName | String(10) |  | 用户名 |
| MPwd | String(32) |  | 密码，md5加密（utf8,x2） |
| MType | integer |  | 类型，0为普通店员，1为经理 |

# 会员等级表MemberTypeInfo

| 列名 | 类型 | 约束 | 说明 |
| --- | --- | --- | --- |
| MId | integer | 主键，自增长 | 编号 |
| MTitle | String(10) |  | 会员类型名称，如钻石会员 |
| MDiscount | Decimal(3,2) |  | 折扣，如0.98 |
| MIsDelete | boolean |  | 是否删除 |

# 会员表MemberInfo

| 列名 | 类型 | 约束 | 说明 |
| --- | --- | --- | --- |
| MId | integer | 主键，自增长 | 编号 |
| MName | String(10) |  | 姓名 |
| MPhone | String(11) |  | 手机号 |
| MMoney | Decimal(6,2) |  | 账户余额 |
| MTypeId | integer |  | 类型，引用MemberTypeInfo表的Tid列 |
| MIsDelete | boolean |  | 是否删除 |

# 菜品分类表DishTypeInfo

| 列名 | 类型 | 约束 | 说明 |
| --- | --- | --- | --- |
| DId | integer | 主键，自增长 | 编号 |
| DTitle | String(10) |  | 菜品类型名称，如湘菜、酒水、主食 |
| DIsDelete | boolean |  | 是否删除 |

# 菜品表DishInfo

| 列名 | 类型 | 约束 | 说明 |
| --- | --- | --- | --- |
| DId | integer | 主键，自增长 | 编号 |
| DTitle | String(10) |  | 名称 |
| DPrice | Decimal(5,2) |  | 价格 |
| DChar | String(10) |  | 名称中每个字的首字母 |
| DTypeId | ingeter |  | 菜品类型，引用DishTypeInfo表的DId列 |
| DIsDelete | boolean |  | 是否删除 |

# 厅包表HallInfo

| 列名 | 类型 | 约束 | 说明 |
| --- | --- | --- | --- |
| HId | integer | 主键，自增长 | 编号 |
| HTitle | String(10) |  | 名称，如昆仑厅、包间 |
| HIsDelete | boolean |  | 是否删除 |

# 餐桌表TableInfo

| 列名 | 类型 | 约束 | 说明 |
| --- | --- | --- | --- |
| TId | integer | 主键，自增长 | 编号 |
| TTitle | String(10) |  | 餐桌名称，为包间类型的餐桌起命名，如北京包、山西包 |
| THallId | integer |  | 厅包信息，引用HallInfo表的Hid列 |
| TIsFree | boolean |  | 是否空闲 |
| TIsDelete | boolean |  | 是否删除 |

# 订单表OrderInfo

| 列名 | 类型 | 约束 | 说明 |
| --- | --- | --- | --- |
| OId | integer | 主键，自增长 | 编号 |
| MemberId | integer |  | 会员编号，引用MemberInfo表的Mid列 |
| TableId | integer |  | 餐桌编号，引用TableInfo表的TId列 |
| ODate | datetime |  | 下单时间 |
| OMoney | Decimal(7,2) |  | 消费金额 |
| IsPay | boolean |  | 是否结账 |
| Discount | Decimal |  | 结账时的折扣 |

# 订单详细表OrderDetailInfo

| 列名 | 类型 | 约束 | 说明 |
| --- | --- | --- | --- |
| OId | integer | 主键，自增长 | 编号 |
| OrderId | integer |  | 订单编号，引用OrderInfo表的OId列 |
| DishId | integer |  | 菜品编号，引用DishInfo表的Did列 |
| Count | integer |  | 份数 |

# Socket 学习记录 网络通信
实现了聊天室功能，客户端连接服务器发送消息，服务器对所有客户端进行转发
